﻿using ArchTest.Domain.Commands;
using ArchTest.Domain.Rules;
using ArchTest.Domain.Services.Interfaces;
using ArchTest.EF;
using ArchTest.Entity;
using CQRSlite.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ArchTest.Domain.Handlers
{
    public class InkoopOrderCommandHandler :
        ICommandHandler<CreateInkoopOrder>,
        ICommandHandler<AddLaadPlaats>,
        ICancellableCommandHandler<VerlaadBeurtAanvragen>
    {
        private readonly ArchTestContext _dbContext;
        private readonly IEnumerable<IRule> _rules;
        private readonly IVerlaadBeurtService _verlaadBeurtService;

        public InkoopOrderCommandHandler(
            ArchTestContext dbContext,
            IEnumerable<IRule> rules,
            IVerlaadBeurtService verlaadBeurtService)
        {
            _dbContext = dbContext;
            _rules = rules;
            _verlaadBeurtService = verlaadBeurtService;
        }

        /// <summary>
        /// Lijkt me wel prima en to-the-point
        /// </summary>
        public async Task Handle(CreateInkoopOrder message)
        {
            var inkoopOrder = new InkoopOrder();
            inkoopOrder.Create(
                message.OpdrachtgeverId,
                message.BevrachterId,
                message.LadingId,
                message.Hoeveelheid);

            await _dbContext.InkoopOrders.AddAsync(inkoopOrder);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Bij iedere command de inkooporder ophalen en de juiste includes bepalen. In dit geval 'laadplaatsen' includen omdat laadplaats al child toegevoegd moet worden
        /// </summary>
        public async Task Handle(AddLaadPlaats message)
        {
            var inkoopOrder = await GetInkoopOrderById(
                message.InkoopOrderId,
                o => o.LaadPlaatsen);

            var plaats = new InkoopOrderPlaats();
            plaats.Create(
                message.PlaatsId,
                message.VestigingId,
                message.OverslagId);

            inkoopOrder.AddLaadPlaats(plaats);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// In InkoopOrderCommandHandler of een nieuwe handler voor InkoopOrderPlaats?
        /// Moet dan voor ieder complex-type-property binnen InkoopOrder een handler komen?
        /// Ik kan me herinneren dat de CustomerAggregate zo'n mega grote draak was bij anycoin omdat het ook als doorgeefluik fungeerde
        /// </summary>
        public async Task Handle(VerlaadBeurtAanvragen message, CancellationToken token = default)
        {
            var inkoopOrder = await GetInkoopOrderById(
                message.InkoopOrderId,
                o => o.LaadPlaatsen);

            var inkoopOrderPlaats = GetInkoopOrderPlaatsById(inkoopOrder, message.InkoopOrderPlaatsId);

            ValidateRules(message);

            inkoopOrderPlaats.VerlaadBeurtAanvragen(message.SchipId, message.Datum, message.Bijzonderheden);

            await _dbContext.SaveChangesAsync();

            // Juiste plek om zo'n domain service aan te roepen die non-domain-dingen uitvoert?
            await _verlaadBeurtService.VerlaadBeurtAanvraagMailSturen(inkoopOrderPlaats);
        }

        private async Task<InkoopOrder> GetInkoopOrderById(Guid inkoopOrderId, params Expression<Func<InkoopOrder, object>>[] includes)
        {
            var query = _dbContext.InkoopOrders.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var inkoopOrder = await query.FirstOrDefaultAsync(o => o.Id == inkoopOrderId);
            if (inkoopOrder == null)
            {
                throw new ArgumentException("InkoopOrder not found");
            }

            return inkoopOrder;
        }

        private InkoopOrderPlaats GetInkoopOrderPlaatsById(InkoopOrder inkoopOrder, Guid inkoopOrderPlaatsId)
        {
            var inkoopOrderPlaats = inkoopOrder.LaadPlaatsen.FirstOrDefault(lp => lp.Id == inkoopOrderPlaatsId);
            if (inkoopOrderPlaats == null)
            {
                throw new ArgumentException($"InkoopOrderPlaats {inkoopOrderPlaatsId} not found on order {inkoopOrder.Id}");
            }

            return inkoopOrderPlaats;
        }

        private void ValidateRules(ICommand command)
        {
            var rules = _rules.Where(rule => rule.ShouldBeExecuted(command));
            foreach (var rule in rules)
            {
                rule.Execute();
            }
        }
    }
}
