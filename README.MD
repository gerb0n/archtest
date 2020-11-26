Gebruik gemaakt van CQRSLite, handig denk je? (https://github.com/gautema/CQRSlite)

Hoe we business-rules correct kunnen opzetten is nog even een vraagstuk.
    Hoe krijgen we de juiste data bij de business-rule?
    En wat als een business-rule afhankelijk is van stam-data dat buiten de aggregate leeft. Hoe krijgen we die data bij de rule? 
        - Repository / DBContext injecten lijkt een slecht idee
        - Een 'RuleContext' meegeven aan de rule, en deze context vullen de commandhandler voelt ook lelijk. RuleContext gaat een verzamelbak worden voor allerlei rules

Kunnen we iets met readmodels voor elkaar krijgen?
We willen het writemodel het liefst niet meer gebruiken om te querieën. Wat is een goede (midden)weg om readmodels te introduceren?

In de huidige versie heb ik al wel readmodels/events geintroduceerd (op de manier zoals CQRS Lite het heeft gedaan in sample-project).
Het werkt alleen nog niet, de handlers van readmodels worden niet getriggered/aangeroepen omdat ik her en der wat shortcurts heb genomen met CQRSLite.

Mocht het wel werken lopen we nog tegen het feit aan: wat als er een veld bij moet komen op een readmodel. We hebben geen events die afgespeeld kunnen worden.
Moeten we dit oplossen met een eigen geschreven sync-functie die het writemodel naar readmodel omzet? Maar dat lijkt me een lastige, niet haalbare taak.
Kunnen we simpelweg onze events persisten in een eventstore zoals in de sample van CQRSLite?
Maar wat is de impact van zo'n eventstore introduceren en moeten we dit wel willen? 

Moeten we door die complexiteit uberhaubt wel readmodels willen en misschien wel commands en queries introduceren (wat het onderhoudbaarder en testbaarder maakt).
Maar niet de events/readmodels op de manier zoals CQRS dat voorschrijft? Maar wat betekent die keuze in de praktijk?
Dat we gewoon maar zware queries moeten uitvoeren op ons writemodel? Kunnen we die pijn op andere manieren nog verzachten?