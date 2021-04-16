using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
using System.Reflection;

namespace LostPeopleRegisterApp.Src.AccountUtil
{
    /// <summary>
    /// Klasa zawierająca zestaw metód do zarządzania obiektami kont użytkowników.
    /// </summary>
    public class AccountUtils
    {
        /// <summary>
        /// Metoda ma za zadanie zaktualizować wszystkie pola konta pod parametrem "current" wartościami
        /// z pól "newAccount"
        /// </summary>
        /// <param name="current">Konto, które należy zaktualizować</param>
        /// <param name="newAccount">Konto, z którego będziemy pobierali dane do zaktualizowania</param>
        /// <returns>
        ///     Zwraca konto z zaktualizowanyki polami
        /// </returns>
        /// <see cref="Account"/>
        public static Account updateAccount(Account current, Account newAccount)
        {
            typeof(Account).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(prop => prop.GetValue(newAccount) != null)
                .Where(prop => prop.GetValue(current).GetType().IsPrimitive || prop.GetValue(current).GetType() == typeof(string) || prop.GetValue(current).GetType() == typeof(DateTime))
                .ForEach(prop => prop.SetValue(current, prop.GetValue(newAccount)));
                
            return current;
        }



        /// <summary>
        /// Metoda sprawdza, czy konto posiada uprawnienia administratora
        /// </summary>
        /// <param name="account">Konto do sprawdzenia</param>
        /// <returns>
        ///     Zwraca 'true' jeżeli konto posiada takie uprawnienia.
        ///     Zwraca 'false' w przeciwnym przypadku
        /// </returns>
        public static bool isAdmin(Account account) => account.accountRole.name == "Administrator";
    }
}