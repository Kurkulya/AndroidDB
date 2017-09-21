using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Queries;

namespace Tests.UI_Control
{
    class AndroidDataBase : IPageObject
    {

        public Func<AppQuery, AppQuery> UpdateBtn { get; } = c => c.Id("updBtn");
        public Func<AppQuery, AppQuery> CreateBtn { get; } = c => c.Id("btnCreate");
        public Func<AppQuery, AppQuery> DeleteBtn { get; } = c => c.Id("delBtn");

        public Func<AppQuery, AppQuery> OLastName { get; } = c => c.Id("tvLastName");
        public Func<AppQuery, AppQuery> OFirstName { get; } = c => c.Id("tvFirstName");
        public Func<AppQuery, AppQuery> OAge { get; } = c => c.Id("tvAge");
        public Func<AppQuery, AppQuery> OId { get; } = c => c.Id("tvId");

        public Func<AppQuery, AppQuery> ILastName { get; } = c => c.Id("crLastName");
        public Func<AppQuery, AppQuery> IFirstName { get; } = c => c.Id("crFirstName");
        public Func<AppQuery, AppQuery> IAge { get; } = c => c.Id("crAge");
        public Func<AppQuery, AppQuery> IId { get; } = c => c.Id("crId");

        public Func<AppQuery, AppQuery> ICreateBtn { get; } = c => c.Id("crBtn");
        public Func<AppQuery, AppQuery> UUpdateBtn { get; } = c => c.Id("saveBtn");

        public Func<AppQuery, AppQuery> ULastName { get; } = c => c.Id("editLastName");
        public Func<AppQuery, AppQuery> UFirstName { get; } = c => c.Id("editFirstName");
        public Func<AppQuery, AppQuery> UAge { get; } = c => c.Id("editAge");
        public Func<AppQuery, AppQuery> UId { get; } = c => c.Id("editId");
    }
}
