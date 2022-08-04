using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;
using Translator.Repository.Interface;
using Translator.Repository;
using Translator.Service.Interface;
using Tranlator.Service;

namespace Tranlator.Tests;

public class Tests
{
    ITranslatorService _service;
    ITranslatorRepository _repository;
    List<Tuple<string, string, string>> words;

    [SetUp]
    public void Setup()
    {
        string eng1 = "Farnborough International Airshow, biennial global aerospace, defence and space trade event which showcases the latest commercial and military aircraft. Manufacturers such as Airbus and Boeing are expected to display their products and announce new orders * 2020 event was held virtually after the physical show was cancelled due to the coronavirus (COVID-19) pandemic";
        string french1 = "Farnborough International Airshow, événement commercial biennal mondial de l'aérospatiale, de la défense et de l'espace qui présente les derniers avions commerciaux et militaires. Des fabricants tels qu'Airbus et Boeing devraient présenter leurs produits et annoncer de nouvelles commandes * L'événement 2020 a eu lieu pratiquement après l'annulation du salon physique en raison de la pandémie de coronavirus (COVID-19)";

        string eng2 = "Labour market statistics: integrated national release, including the latest data for employment, economic activity, economic inactivity, unemployment, claimant count, average earnings, productivity, unit wage costs, vacancies & labour disputes";
        string french2 = "Statistiques sur le marché du travail : diffusion nationale intégrée, y compris les dernières données sur l'emploi, l'activité économique, l'inactivité économique, le chômage, le nombre de demandeurs, les gains moyens, la productivité, les coûts salariaux unitaires, les postes vacants";

        string eng3 = "City of London Corporation's Financial and Professional Services dinner. Chancellor Rishi Sunak and Bank of England Governor Andrew Bailey make their annual Mansion House speeches at the event hosted by the Lord Mayor of the City of London Vincent Keaveny";
        string french3 = "Dîner des services financiers et professionnels de la City of London Corporation. Le chancelier Rishi Sunak et le gouverneur de la Banque d'Angleterre Andrew Bailey prononcent leurs discours annuels à Mansion House lors de l'événement organisé par le lord-maire de la ville de Londres Vincent Keaveny";


        words = new List<Tuple<string, string, string>>();
        words.Add(new Tuple<string, string, string>("test words", "fr", "mots d'essai"));
        words.Add(new Tuple<string, string, string>(eng1, "fr", french1));
        words.Add(new Tuple<string, string, string>(eng2, "fr", french2));
        words.Add(new Tuple<string, string, string>(eng3, "fr", french3));
    }


    [Test]
    public void Translate_TestWorld_MoteDessai()
    {
        //Arrange
        var _TranslatorService = new TranslatorRepository(new TranslatorService());
        //Act
        string result = "";
        foreach (var item in words)
        {
            result = _TranslatorService.Translate(item.Item1, item.Item2);
            Assert.AreEqual(item.Item3, result);
        }
        //string words = "test words";
        //string result = this._repository.Translate(words, "fr");

        //Assert
        //Assert.AreEqual("mots d'essai", result);
    }
}