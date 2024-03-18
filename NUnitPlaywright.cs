using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Playwright_Demo;

//Our NUnitPlywright class will now be inheriting from PageTest, which is a NUnit derived class
//This means that we won't need the Playwright and Browser and Page under the Task Test1 method
public class NUnitPlaywright : PageTest 
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync( url:"http://eaapp.somee.com");
    }

    [Test]
    public async Task Test2()
    {               
        await Page.ClickAsync( selector: "text=Login");        
        await Page.FillAsync( selector:"#UserName", value:"admin");
        await Page.FillAsync( selector:"#Password", value:"password");
        await Page.ClickAsync( selector:"text=Log In");
        /* var isExist = await Page.Locator( selector:"text='Employee Details'").IsVisibleAsync();
        Assert.IsTrue(isExist); */
        //We can replace the above assertion line of code using the 'Expect' method which gives the ILocator assertion interface that automates the code i.e:
        await Expect(Page.Locator( selector:"text='Employee Details'")).ToBeVisibleAsync();

        
        
        

    }
}