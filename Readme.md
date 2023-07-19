<h1>Projet Calcul de prix</h1>
<h3>Vous êtes chargé de développer une application permettant de prévisualiser un prix de vente en partant d’un montant initial.</h3>


Vous devez développer une API backend en .Net Core qui sera responsable du moteur de calcul.

Voici les fonctionnalités demandées :

- Un endpoint prenant en paramètre un prix initial et retournant un prix de vente.


Les règles sont les suivantes :

- Règle 1 :

  - Le prix de vente = prix initial + commission
  - La commission est un pourcentage du prix initial.

La formule est la suivante :

    Prix de vente = prix initial + (prix initial * taux de commission)

- Règle 2 : 

  - Le prix de vente peut être HT ou TTC, pour appliquer la TVA, il faut y rajouter 20%.

Le calcul est le suivant :

    Prix de vente TTC = prix de vente HT + (prix de vente HT * 20%) ou prix de vente TTC = prix de vente HT * 1.20


En utilisant React, l'application devrait permettre aux utilisateurs d’afficher le résultat selon les informations fournies.


Voici les fonctionnalités demandées :

- Formulaire comprenant :

  - un champ de saisie permettant de renseigner le montant initial.
  - Un composant permettant de passer le montant HT en montant TTC.
  - Un bouton pour soumettre les paramètres.
  - Un bouton pour réinitialiser tous les composants.

Votre code sera évalué en fonction des critères suivants :


- Architecture globale de l'application (front-end et back-end)
- Organisation et qualité du code.
- Respect des fonctionnalités requises.
- Communication efficace entre le front-end React et le back-end .NET. 

- Utilisation appropriée des technologies et des bonnes pratiques.

Remarque :
 - La non complétion de ce test n’est pas éliminatoire (pas de pression)
 - Vous êtes libre d'ajouter des fonctionnalités supplémentaires à l'application si vous le souhaitez pour démontrer vos compétences et votre créativité.