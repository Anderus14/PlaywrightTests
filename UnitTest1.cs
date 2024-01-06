using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[TestFixture]
public class Tests : PageTest
{
	private ILocator DynamicIdButton() => Page.Locator("//a[text()='Dynamic ID']");
	private ILocator TextInputButton() => Page.Locator("//a[text()='Text Input']");
	
	[SetUp]
	public async Task Setup()
	{
		await Page.GotoAsync("http://uitestingplayground.com");
	}
	[Test]
	public async Task DynamicIdButtonTest()
	{
		await DynamicIdButton().ClickAsync();
		DynamicIdPage dynamicIdPage = new DynamicIdPage(Page);
		await Expect(Page).ToHaveURLAsync("http://uitestingplayground.com/dynamicid");
		await Expect(dynamicIdPage.PageLabel()).ToHaveTextAsync("Dynamic ID");
		await dynamicIdPage.DynamicIdButton().ClickAsync();
	}
	
	[Test]
	public async Task TextInputTest()
	{
		await TextInputButton().ClickAsync();
		TextInputPage textInputPage = new TextInputPage(Page);
		await Expect(Page).ToHaveURLAsync("http://uitestingplayground.com/textinput");
		await Expect(textInputPage.MyButtonInput()).ToHaveAttributeAsync("placeholder","MyButton");
		await Expect(textInputPage.UpdatingButton()).ToHaveTextAsync("Button That Should Change it's Name Based on Input Value");
		await textInputPage.InputEnterText("dupa kota");
		await textInputPage.ClickButton();
		await Expect(textInputPage.UpdatingButton()).ToHaveTextAsync("dupa kota");
	}
}