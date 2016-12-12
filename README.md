# AppChat-VB.net

## Prérequis

* Microsoft .NET Framework 3.5, https://www.microsoft.com/fr-fr/download/details.aspx?id=21

## Utilisation

* Générez la solution
* Lancer l'application serveur sur un poste
* déployer et lancer l'application client sur les postes des utilisateurs

Attention: Avant de générer l'application client, n'oublier pas de remplacer l'adresse IP du serveur par celle de l'ordinateur qui hébergera le serveur.
```vb.net
    Private ipServeur As IPAddress = IPAddress.Parse("172.16.1.128")
```