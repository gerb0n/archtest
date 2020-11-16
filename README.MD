Er zit een swagger-page bij dus je kan:
- een order toevoegen
- een laadplaats toevoegen
- een laadbeurt aanvragen
- alle orders ophalen.

Gebruik gemaakt van CQRSLite, handig denk je? (https://github.com/gautema/CQRSlite)
Gebruik eigenlijk alleen maar de commandsender/commands hiervan. Heb niet het gevoel dat ik helemaal de vruchten pluk van QRS op de huidige manier.

Comments staan in:
- InkoopOrderCommandHandler
- MaxEenVerlaadBeurtAanvraagRule
- VerlaadBeurtService
- InkoopOrder