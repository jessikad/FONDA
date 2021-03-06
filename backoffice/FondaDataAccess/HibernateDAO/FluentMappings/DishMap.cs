﻿using System;
using FluentNHibernate.Mapping;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings
{
    public class DishMap
        : ClassMap<com.ds201625.fonda.Domain.Dish>
    {
        public DishMap()
        {
            Table("DISH");

            Id(x => x.Id)
                .Column("dis_id")
                .Not.Nullable()
                .GeneratedBy.Increment();

            Map(x => x.Name)
                .Column("dis_name")
                .Not.Nullable();

            Map(x => x.Description)
                .Column("dis_description")
                .Not.Nullable();

            Map(x => x.Image)
                .Column("dis_image");

            References(x => x.Status)
                .Column("fk_dis_status")
                .Not.Nullable()
                .Cascade.Persist();

            Map(x => x.Suggestion)
                .Column("dis_suggestion")
                 .Not.Nullable();

            Map(x => x.Cost)
                .Column("dis_cost")
                .Not.Nullable();
                


        }
    }
}
