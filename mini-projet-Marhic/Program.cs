﻿using System;
using System.Xml.Linq;

class miniProjetMarhic
{
    /// <summary>
    /// ajoute un string à une liste, en suivant le principe d'une pile.
    /// </summary>
    /// <param name="pile">Liste de string, représentant une pile.</param>
    /// <param name="valeur">valeur à ajouter dans la pile.</param>
    public static void push(List<string>pile, string valeur)
    {
        pile.Add(valeur);
    }

    /// <summary>
    /// récupère l'élèment au dessus de la pile.
    /// </summary>
    /// <param name="pile">Liste de string, représentant une pile.</param>
    /// <returns>retourne la dernière valeur de la liste.</returns>
    public static string top(List<string> pile)
    {
        return pile[pile.Count()-1];
    }

    /// <summary>
    /// Enlève le dernier élément et le renvoie.
    /// </summary>
    /// <param name="pile">La liste de string, représentant une pile.</param>
    /// <returns>retourne la valeur supprimée.</returns>
    public static string pop(List<string> pile)
    {
        string val = top(pile);
        pile.RemoveAt(pile.Count() - 1); //Suppression du dernier élément de la liste.
        return val;
    }

    /// <summary>
    /// Récupère le calcul de l'utilisateur (input)
    /// </summary>
    /// <returns>retourne l'expression entrée.</returns>
    public static List<string> getCalcul()
    { 
        List<string> expression = new List<string>(); //Déclaration d'une nouvelle liste qui contiendra l'expression
        Console.WriteLine("Entrez le calcul : \n");
        string calcul = Console.ReadLine(); //Entrée utilisateur.
        List<String> elementExpression = calcul.Split(' ').ToList(); //Enlève les espaces de l'expression.

        for(int i = 0; i < elementExpression.Count; i++) //parcours l'expression.
        {
            push(expression, elementExpression[i]);// ajout de chaque élément de l'expression à une 
        }
        return expression;
    }

    /// <summary>
    /// Effectue le calcul à partir de l'expression donnée.
    /// </summary>
    /// <param name="expression">Expression entrée par l'utilisateur.</param>
    /// <returns>Retourne la somme finale.</returns>
    public static float Calcul(List<string> expression)
    {
       
        List<string> pile = new List<string>();
        float somme = 0;
        float premiereValeur = 0;
        float deuxiemeValeur = 0;

        foreach (string element in expression) //Parcours tous les éléments de l'expression
        {
            try //Utilisé pour throw une exception si il y a une erreur.
            {
                switch (element) //Utilisé pour chaque opérateur.
                {
                    case "+":
                        deuxiemeValeur = float.Parse(pop(pile));
                        Console.WriteLine("Premiere valeur :" + premiereValeur);
                        premiereValeur = float.Parse(pop(pile));
                        Console.WriteLine("deuxieme valeur :" + deuxiemeValeur);
                        if(premiereValeur < 0 || deuxiemeValeur < 0) {

                            throw new Exception("Erreur : Valeurs négatives interdites.");
                        }
                        else
                        {
                            somme = premiereValeur + deuxiemeValeur;
                            push(pile, somme.ToString());
                        }                        
                        break;
                    case "-":
                        deuxiemeValeur = float.Parse(pop(pile));
                        Console.WriteLine("Premiere valeur :" + premiereValeur);
                        premiereValeur = float.Parse(pop(pile));
                        Console.WriteLine("deuxieme valeur :" + deuxiemeValeur);
                        if (premiereValeur >= 0 && deuxiemeValeur >= 0)
                        {
                            somme = premiereValeur - deuxiemeValeur;
                            push(pile, somme.ToString());
                        }
                        else
                        {
                            throw new Exception("Erreur : Valeurs négatives interdites.");
                        }
                        
                        break;
                    case "/":
                        deuxiemeValeur = float.Parse(pop(pile));
                        Console.WriteLine("Premiere valeur : " + premiereValeur);
                        premiereValeur = float.Parse(pop(pile));
                        Console.WriteLine("deuxieme valeur :" + deuxiemeValeur);

                        if(premiereValeur == 0 || deuxiemeValeur < 0 || premiereValeur < 0)
                        {
                            Console.WriteLine("Erreur : Impossible de diviser par 0 ou d'envoyer des nombres négatifs.");
                            throw new Exception("Erreur : Valeurs négatives interdites.");
                        }
                        else
                        {
                            somme = premiereValeur / deuxiemeValeur;
                            push(pile, somme.ToString());
                        }
                        break;
                    case "*":
                        deuxiemeValeur = float.Parse(pop(pile));
                        Console.WriteLine("Premiere valeur : " + premiereValeur);
                        premiereValeur = float.Parse(pop(pile));
                        Console.WriteLine("deuxieme valeur :" + deuxiemeValeur);
                        if (premiereValeur >= 0 && deuxiemeValeur >= 0)
                        {
                            somme = premiereValeur * deuxiemeValeur;
                            push(pile, somme.ToString());
                        }
                        else
                        {
                            throw new Exception("Erreur : Valeurs négatives interdites.");
                        }
                        
                        break;
                    default:
                        push(pile, element);
                        break;
                }
            }
            catch
            {
                throw (new Exception("Erreur : Calcul infaisable; ressaisir. \n"));
            }
            
        }
        return somme;
    }

    /// <summary>
    /// Boucle pour l'execution apres chaque calcul, appel la fonction.
    /// </summary>
    static void Main()
    {
        bool programRunning = true;

        do
        {
            float somme = Calcul(getCalcul());
            Console.WriteLine(somme);

        } while (programRunning);
        
    }


}



