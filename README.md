#GroceryApp sprint5 Studentversie  
Dit is de startversie voor studenten van sprint 6.

## GitFlow Workflow

Dit project maakt gebruik van een aangepaste GitFlow-structuur.  
Hieronder staat uitgelegd hoe we met branches werken en hoe je nieuwe code toevoegt.

### Branches
- **main**  
  Bevat de stabiele productiecode. Alleen releases en hotfixes komen hier terecht.

- **develop**
  Hier wordt alle ontwikkelcode samengebracht vanuit feature-branches.  
  Beschouw dit als de "werkversie" die klaarstaat voor de volgende release.

- **release/**  
  Wordt pas aangemaakt als de develop branch stabiel genoeg is om een release te maken.  
  Bijvoorbeeld: `release/release-v1.0.0`.

- **feature/**  
  Elke nieuwe feature of use case krijgt zijn eigen branch.  
  Bijvoorbeeld:
    - `feature/UC05`
    - `feature/UC06`

- **hotfix/**  
  Wordt gebruikt om dringende fixes te doen op productiecode.  
  Bijvoorbeeld: `hotfix/hotfix-v1.0.1`.
  Deze word vanuit de main branch gemaakt en na afronding gemerged naar zowel main als develop.

### Use Cases
 
UC17 Boodschappenlijst in database is compleet uitgewerkt.  

UC18 BoodschappenlijstItems in database.  
- Gebruik het voorbeeld van UC17 om zelf de GroceryListItemsRepository tew ijzigen zodat boodschappenlijstitems uit de database komen.  

UC19 Product in database en nieuw product aanmaken --> zelfstandig uitwerken.  
- Volg UC17 om producten uit de database te kunnen halen.  
- De Add() functie in ProductService moet uitgewerkt zijn om nieuwe producten te kunnen aanmaken.  
- Maak een NewProductViewModel om het aanmaken van nieuwe producten te ondersteunen. Alleen gebruikers met de admin Role mogen nieuwe producten aanmaken.  
- Maak een NewProductView voor het invoerscherm.  
- Voeg een ToolbarItemn toe aan de ProductView, zodat vanuit dit scherm nieuwe producten kunnen worden aangemaakt.  
- Zorg ervoor dat als er een nieuw product is aangemaakt, deze meteen zichtbaar is in de Productlijst van de ProductView.  
- Denk aan de registratie van de View, ViewModel en registreren van de route naar NewProductView.  






