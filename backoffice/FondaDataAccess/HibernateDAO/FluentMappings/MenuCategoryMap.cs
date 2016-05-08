﻿using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class MenuCategoryMap : ClassMap<com.ds201625.fonda.Domain.MenuCategory>
    {
        public MenuCategoryMap()
        {
            Table("MENUCATEGORY");

            Id(x => x.Id)
              .Column("cat_menu_id")
              .Not.Nullable()
              .GeneratedBy.Increment();

            Map(x => x.Name)
              .Column("cat_menu_name")
              .Not.Nullable();

            References(x => x.Status)
                .Column("fk_cat_status")
                .Not.Nullable();

            References(x => x.RecordStatus)
              .Column("fk_cat_record");
              .Not.Nullable();

            HasMany(x => x.ListDish)
                .KeyColumn("fk_menu_dish")
                .ExtraLazyLoad()
                .Cascade.All();


            //TOdavia no falta que restarant cree su mappa
            /*References(x => x.Restaurant)
             .Column("fk_id_restaurant")
             .Not.Nullable();*/

        }
    }
}
