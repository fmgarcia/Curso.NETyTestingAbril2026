using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tienda.E2E.Tests.Suport;

namespace Tienda.E2E.Tests.Test
{
    public class PrimerTest : PlaywrightTestBase
    {

        [Test]
        public async Task PaginaPrincipal_MuestraTitulo()
        {
            await Page.GotoAsync(TestSettings.BaseUrl);

            await Expect(Page).ToHaveTitleAsync(new Regex("Inicio"));
        }


    }
}
