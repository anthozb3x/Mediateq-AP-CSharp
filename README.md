# Documentation utilisateur pour l'application C# Mediateq réalisée par Anthony Béal

## Contexte

Le SI de Mediateq est ancien et les applications sont devenues difficilement maintenables. Mediateq souhaite donc les réécrire. Vous travaillez dans l'ESN chargée de cette refonte des applications. Dans un premier temps, seule l'application de gestion du catalogue est concernée. Cette application sera utilisée sur site par les employés de la médiathèque et sera en architecture client lourd. Les différents développements sont les suivants :

- :closed_lock_with_key: Système d'authentification dans l'application
- :file_folder: Gestion des exemplaires de documents (consultation, réception)
- :bookmark_tabs: Gestion des commandes de livres ou DVD
- :mag_right: Suivi de l'état des documents
- :busts_in_silhouette: Gestion des abonnés

J'ai réalisé les sprints suivants :

- :closed_lock_with_key: Système d'authentification dans l'application
- :bookmark_tabs: Gestion des commandes de livres ou DVD
- :busts_in_silhouette: Gestion des abonnés

# Guide d'utilisation

## Se connecter

Pour vous connecter, saisissez votre adresse e-mail et votre mot de passe dans le formulaire suivant :

<p align="center">
  <img src="https://github.com/anthozb3x/Mediateq-AP-CSharp/assets/78346006/9a36052b-9620-4da3-ad53-115358a63d10" alt="Formulaire de connexion" width="400">
</p>

Si les informations que vous avez fournies sont correctes, vous serez redirigé vers la page suivante :

<p align="center">
  <img src="https://github.com/anthozb3x/Mediateq-AP-CSharp/assets/78346006/a0bb9a31-e43d-409d-b2b5-54e0a3143657" alt="Page de formulaire" width="600">
</p>

Si vous avez plusieurs onglets, cela est normal et dépend de vos droits sur l'application.

## Se déconnecter

Pour vous déconnecter, cliquez sur le bouton "Déconnexion" en haut à gauche de l'application. :door:

<p align="center">
  <img src="https://github.com/anthozb3x/Mediateq-AP-CSharp/assets/78346006/2b3c8ece-b604-459a-a808-548b383a8d3d" alt="Déconnexion" width="300">
</p>

## Ajouter, modifier, supprimer un DVD

Rendez-vous dans l'onglet "DVDCRUD" :
- Pour le modifier, remplissez les champs que vous souhaitez modifier et cliquez sur le bouton "Modifier le DVD" :pencil2:
- Pour le supprimer, cliquez sur le bouton "Supprimer le DVD" :x:
- Pour ajouter un DVD, remplissez les informations du DVD que vous souhaitez ajouter et cliquez sur "Ajouter le DVD" :heavy_plus_sign:

<p align="center">
  <img src="https://github.com/anthozb3x/Mediateq-AP-CSharp/assets/78346006/bbd75bab-3fb5-4098-b494-1983a3dde6b3" alt="DVDCRUD" width="400">
</p>

## Ajouter, modifier, supprimer un livre

Rendez-vous dans l'onglet "Livres CRUD" :
- Pour le modifier, remplissez les champs que vous souhaitez modifier et cliquez sur le bouton "Modifier le livre" :pencil2:
- Pour le supprimer, cliquez sur le bouton "Supprimer le livre" :x:
- Pour ajouter un livre, remplissez les informations du livre que vous souhaitez ajouter et cliquez sur "Ajouter le livre" :heavy_plus_sign:

<p align="center">
  <img src="https://github.com/anthozb3x/Mediateq-AP-CSharp/assets/78346006/35e8d77e-3389-42e1-920f-dbd3b497ba6d" alt="Livre CRUD" width="400">
</p>

## Ajouter, modifier, supprimer un abonné

Rendez-vous dans l'onglet "Abonné" :
- Pour le modifier, remplissez les champs que vous souhaitez modifier et cliquez sur le bouton "Modifier Abonné" :pencil2:
- Pour le supprimer, cliquez sur le bouton "Supprimer un Abonné" :x:
- Pour ajouter un abonné, remplissez les informations de l'abonné que vous souhaitez ajouter et cliquez sur "Ajouter un Abonné" :heavy_plus_sign:

<p align="center">
  <img src="https://github.com/anthozb3x/Mediateq-AP-CSharp/assets/78346006/d546c5ce-006a-4e8b-b00f-ad82ba057848" alt="Abonné CRUD" width="400">
</p>
