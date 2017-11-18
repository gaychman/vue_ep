using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP.Components.DKB
{
    public class DocumentModel
    {
        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название документа
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Ссылка на документ во внешнем хранилище
        /// </summary>
        public String ExternalRef { get; set; }
    }
}
