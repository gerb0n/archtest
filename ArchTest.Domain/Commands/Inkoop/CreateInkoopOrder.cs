using ArchTest.Core.Attributes;
using CQRSlite.Commands;
using System;

namespace ArchTest.Domain.Commands.Inkoop
{
    public class CreateInkoopOrder : ICommand
    {
        public CreateInkoopOrder(
            Guid opdrachtgeverId,
            Guid bevrachterId,
            Guid ladingId,
            int? hoeveelheid)
        {
            OpdrachtgeverId = opdrachtgeverId;
            BevrachterId = bevrachterId;
            LadingId = ladingId;
            Hoeveelheid = hoeveelheid;
        }

        [NotNullOrDefault()]
        public Guid OpdrachtgeverId { get; }

        [NotNullOrDefault]
        public Guid BevrachterId { get; }

        [NotNullOrDefault]
        public Guid LadingId { get; }

        public int? Hoeveelheid { get; }
    }
}