using LostPeopleRegisterApp.Src.AccountUtil;
using LostPeopleRegisterApp.Src.Config;
using LostPeopleRegisterApp.Src.LoginUtil;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LostPeopleRegisterApp.Src.LostPersonUtil
{
    /// <summary>
    /// Klasa przeznaczona do wykonywania zaawansowanych operacji na danych
    /// osób zaginionych
    /// </summary>
    public sealed class LostPersonService
    {
        /// <summary>
        /// Repozytorium osób zaginionych
        /// </summary>
        /// <see cref="LostPersonRepository"/>
        private LostPersonRepository lostPersonRepository { get; set; }

        /// <summary>
        /// Obiekt z podstawową konfiguracją naszej aplikacji
        /// </summary>
        /// <see cref="LostPersonAppConfig" />
        private LostPersonAppConfig lostPersonAppConfig { get; set; }

        /// <summary>
        /// Serwis do logowania się
        /// </summary>
        /// <see cref="LoginService"/>
        private LoginService loginService { get; set; }

        
        



        
        public LostPersonService(LoginService loginService)
        {
            this.lostPersonRepository = LostPersonRepository.INSTANCE;
            this.lostPersonAppConfig = LostPersonAppConfig.INSTANCE;
            this.loginService = loginService;
        }





        /// <summary>
        /// Metoda ma za zadanie zwrócić listę ostatnio utworzonych zaginionych osoób
        /// </summary>
        /// <param name="ammount">Liczba osób do zwrócenia</param>
        /// <returns>
        ///     Zwraca listę osób zaginionych o liczbie równej parametrowi 'ammount'
        /// </returns>
        /// <see cref="LostPerson"/>
        public List<LostPerson> findLastCreatedLostPeople(int ammount) => this.lostPersonRepository.findLastCreatedLostPeople(ammount);



        /// <summary>
        /// Metoda ma za zadanie zwrócić osobę zaginioną według jeggo identyfikatora
        /// </summary>
        /// <param name="id">IDentyfiaktor osoby</param>
        /// <returns></returns>
        /// <see cref="LostPerson"/>
        public LostPerson findById(int id) => this.lostPersonRepository.findById(id);



        /// <summary>
        /// Metoda ta zapisuje nową osobę zaginioną wraz ze wszystkimi danymi w bazie danych.
        /// Jeżeli zdjęcie zostało dodane, to metoda utworzy folder, który
        /// będzie przechowywał zdjęcie dla danej zaginionej osoby
        /// </summary>
        /// <param name="lostPerson">Dane osoby zaginione</param>
        /// <param name="thumbnails">Udostępnione zdjęcie</param>
        /// <see cref="LostPerson"/>
        public void createLostPerson(LostPerson lostPerson, HttpFileCollectionBase thumbnails) 
        {
            Account currentlyLoggedUser = this.loginService.getCurrentlyLoggedAccount();
            lostPerson.createdAccountId = currentlyLoggedUser.id;
            lostPerson.statusId = 1;

            lostPersonRepository.create(lostPerson);
            LostPerson createdLostPerson = lostPersonRepository.getLastCreatedLostPerson();
            currentlyLoggedUser.lostPersonList.Add(createdLostPerson);

            for (int i = 0; i < thumbnails.Count; i++)
            {
                string dirName = this.lostPersonAppConfig.dataFolder.path + "\\" + LostPersonUtils.getFullFilePath(createdLostPerson);

                if (!Directory.Exists(dirName))
                    Directory.CreateDirectory(dirName);

                thumbnails[i].SaveAs(dirName + "\\" + thumbnails[i].FileName);
            }
        }



        /// <summary>
        /// Metoda ma za zadanie zaktualizować dane osoby zaginionej.
        /// Jeżeli imię lub nazwisko zostało zmienione, wówczas zmieniana jest
        /// nazwa folderu ze zdjęciem osoby zginionej
        /// </summary>
        /// <param name="lostPerson"></param>
        public void updateLostPerson(LostPerson lostPerson)
        {
            LostPerson foundLostPerson = this.lostPersonRepository.findById(lostPerson.id);
            lostPerson.additionalDetails = null;
            lostPerson.images = null;
            lostPerson.address.lostPersonId = lostPerson.id;

            this.lostPersonRepository.update(lostPerson);
            LostPerson updated = this.lostPersonRepository.findById(lostPerson.id);

            string prevPath = this.lostPersonAppConfig.dataFolder.path + "\\" + LostPersonUtils.getFullFilePath(foundLostPerson);
            string currPath = this.lostPersonAppConfig.dataFolder.path + "\\" + LostPersonUtils.getFullFilePath(updated);

            if (prevPath != currPath)
                Directory.Move(prevPath, currPath);
        }


        /// <summary>
        /// Metoda ma za zadanie wyszukać osoby zaginione wedlug podstawowych kryteriów wyszukiwania.
        /// Metoda ta posłuży do zwracania wyników w przyadku, gy używamy podstawowej wyszukiwarki na
        /// stronie internetowej. Metoda wyszukuje osoby wedłyug imienia i nazwiska.
        /// </summary>
        /// <param name="criteria">Ciąg znaków, który należy wyszukać</param>
        /// <returns></returns>
        /// <see cref="LostPerson"/>
        public List<LostPerson> findByBasicCriteria(string criteria)
        {
            List<LostPerson> res = this.lostPersonRepository.findAll();
            string[] keywords = criteria.Split(' ');

            keywords.ForEach(keyword =>
            {
                res = res.Where(x => x.firstName.ToLower().Contains(keyword.ToLower()) || x.lastName.ToLower().Contains(keyword.ToLower())).ToList();
            });

            return res.Take(5).ToList();
        }



        /// <summary>
        /// Metoda ma za zadanie zwrócić listę osób zaginionych spełniających wszystkie
        /// wprowadzone w parametrze kryteria.
        /// </summary>
        /// <param name="criteria">Kryteria wyszukiwania</param>
        /// <returns></returns>
        /// <see cref="LostPersonSearchCriteria"/>
        public List<LostPerson> findByAdvancedCriteria(LostPersonSearchCriteria criteria)
        {
            List<LostPerson> res = this.lostPersonRepository.findAll();

            if (criteria.minHeight != null)
                res = res.Where(x => x.height >= criteria.minHeight).ToList();

            if (criteria.maxHeight != null)
                res = res.Where(x => x.height <= criteria.maxHeight).ToList();

            if (criteria.minLostPersonDate != null)
                res = res.Where(x => x.lostPersonDate >= criteria.minLostPersonDate).ToList();

            if (criteria.maxLostPersonDate != null)
                res = res.Where(x => x.lostPersonDate <= criteria.maxLostPersonDate).ToList();

            if (criteria.lastPlaceName != null)
                res = res.Where(x => x.lastPlaceName.ToLower().Contains(criteria.lastPlaceName.ToLower())).ToList();

            if (criteria.statusId != null)
                res = res.Where(x => x.statusId  == criteria.statusId).ToList();

            return res;
        }



        /// <summary>
        /// Metoda ma za zadanie zaktualizować status osoby zaginionej
        /// jako odnaleziony
        /// </summary>
        /// <param name="lostPersonId">Identyfikator osoby zaginione</param>
        public void makeLostPersonFound(int lostPersonId)
        {
            LostPerson lostPerson = this.lostPersonRepository.findById(lostPersonId);
            lostPerson.statusId = 2;

            this.lostPersonRepository.update(lostPerson);
            this.loginService.getCurrentlyLoggedAccount().lostPersonList = this.lostPersonRepository.findByAccountId(this.loginService.getCurrentlyLoggedAccount().id);
        }
    }
}