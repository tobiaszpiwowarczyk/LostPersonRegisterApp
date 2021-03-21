﻿using LostPeopleRegisterApp.Src.LostPersonUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil.AdditionalDetails;
using LostPeopleRegisterApp.Src.LostPersonUtil.Address;
using LostPeopleRegisterApp.Src.LostPersonUtil.Image;
using LostPeopleRegisterApp.Src.AccountUtil;
using System.Data.Entity;

namespace LostPeopleRegisterApp.Src.CustomDatabaseUtil
{
    /// <summary>
    /// Klasa mająca za zadanie konfigurowanie sposobu odczytu oraz zarządzania danymi z bazy danych.
    /// </summary>
    public partial class CustomDatabaseContext : DbContext
    {
        /// <summary>
        /// Pole odpowiedzialne za zarządzanie listą kont użytkowników
        /// </summary>
        /// <see cref="Account"/>
        public DbSet<Account> accounts { get; set; }

        /// <summary>
        /// Pole odpowiedzialne za zarządzanie listą osób zaginionych
        /// </summary>
        /// <see cref="LostPerson"/>
        public DbSet<LostPerson> lostPeople { get; set; }



        public CustomDatabaseContext() : base("name=CustomDatabaseContext") {}



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelBuilderUtils modelBuilderUtils = new ModelBuilderUtils(modelBuilder);

            modelBuilderUtils.createInheritanceMapping<Account>("account");
            modelBuilderUtils.createInheritanceMapping<LostPerson>("lost_person");
            modelBuilderUtils.createInheritanceMapping<LostPersonImage>("lost_person_image");
            modelBuilderUtils.createInheritanceMapping<LostPersonAdditionalDetail>("lost_person_additional_details");
            modelBuilderUtils.createInheritanceMapping<CityLostPersonAddress>("lost_person_address_city");
            modelBuilderUtils.createInheritanceMapping<VillageLostPersonAddress>("lost_person_address_village");

            modelBuilder.Entity<Account>()
                .HasMany(x => x.lostPersonList)
                .WithRequired(x => x.account)
                .HasForeignKey(x => x.createdAccountId);

            modelBuilder.Entity<LostPerson>()
                .HasRequired(x => x.status)
                .WithRequiredPrincipal();

            modelBuilder.Entity<LostPerson>()
                .HasMany(x => x.images)
                .WithRequired(x => x.lostPerson)
                .HasForeignKey(x => x.lostPersonId);

            modelBuilder.Entity<LostPerson>()
                .HasMany(x => x.additionalDetails)
                .WithRequired(x => x.lostPerson)
                .HasForeignKey(x => x.lostPersonId);

            modelBuilder.Entity<LostPersonAddress>()
                .HasRequired(x => x.lostPerson)
                .WithRequiredPrincipal(x => x.address);
        }
    }
}
