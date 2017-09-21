using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Queries;

namespace Tests.UI_Control
{
    public interface IPageObject
    {
        Func<AppQuery, AppQuery> UpdateBtn { get; }
        Func<AppQuery, AppQuery> CreateBtn { get; }
        Func<AppQuery, AppQuery> DeleteBtn { get; }

        Func<AppQuery, AppQuery> OLastName { get; }
        Func<AppQuery, AppQuery> OFirstName { get; }
        Func<AppQuery, AppQuery> OAge { get; }
        Func<AppQuery, AppQuery> OId { get; }

        Func<AppQuery, AppQuery> ICreateBtn { get; }
        Func<AppQuery, AppQuery> UUpdateBtn { get; }

        Func<AppQuery, AppQuery> ILastName { get; }
        Func<AppQuery, AppQuery> IFirstName { get; }
        Func<AppQuery, AppQuery> IAge { get; }
        Func<AppQuery, AppQuery> IId { get; }

        Func<AppQuery, AppQuery> ULastName { get; }
        Func<AppQuery, AppQuery> UFirstName { get; }
        Func<AppQuery, AppQuery> UAge { get; }
        Func<AppQuery, AppQuery> UId { get; }
    }
}
