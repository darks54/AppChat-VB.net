# AppChat-VB.net

## Pr�requis

* Microsoft .NET Framework 3.5, https://www.microsoft.com/fr-fr/download/details.aspx?id=21

## Utilisation

* G�n�rez la solution
* Lancer l'application serveur sur un poste
* d�ployer et lancer l'application client sur les postes des utilisateurs

Attention: Avant de g�n�rer l'application client, n'oublier pas de remplacer l'adresse IP du serveur par celle de l'ordinateur qui h�bergera le serveur.
```vb.net
    Private ipServeur As IPAddress = IPAddress.Parse("172.16.1.128")
```