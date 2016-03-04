using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class AboutViewModel
    {
        public List<ModuleInfoViewModel> Modules { get; set; }

        public AboutViewModel()
        {
            this.Modules = new List<ModuleInfoViewModel>()
            {
                new ModuleInfoViewModel()
                {
                    Name = "Superheroes.Web",
                    Details = "Основной модуль Web-приложения, содержит контроллеры, представления, фильтры и т.д."
                },
                new ModuleInfoViewModel()
                {
                    Name = "Superheroes.Domain",
                    Details = "Модуль предметной области приложения, содержит классы сущностей предметной области"
                },
                new ModuleInfoViewModel()
                {
                    Name = "Superheroes.Logic",
                    Details = "Бизнес логика приложения. В данном случае очень простая."
                },
                new ModuleInfoViewModel()
                {
                    Name = "Superheroes.DA",
                    Details = "Модуль абстракции предметной области от технологии доступа к данным - Data Access Layer"
                },
                new ModuleInfoViewModel()
                {
                    Name = "Superheroes.DA.EF",
                    Details = "Конкретная реализация уровня доступа к данным через EntityFramework"
                }
            };
        }
    }
}