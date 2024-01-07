using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
	private ILocator DynamicIdButton() => Page.Locator("//a[text()='Dynamic ID']");
	private ILocator TextInputButton() => Page.Locator("//a[text()='Text Input']");
	private ILocator VerifyTextButton() => Page.Locator("//a[text()='Verify Text']");
	
	[SetUp]
	public async Task Setup()
	{
		await Page.GotoAsync("http://uitestingplayground.com");
	}
	[Test]
	public async Task DynamicIdButtonTest()
	{
		await DynamicIdButton().ClickAsync();
		Pages.DynamicIdPage dynamicIdPage = new(Page);
		await Expect(Page).ToHaveURLAsync("http://uitestingplayground.com/dynamicid");
		await Expect(dynamicIdPage.PageLabel()).ToHaveTextAsync("Dynamic ID");
		await dynamicIdPage.DynamicIdButton().ClickAsync();
	}
	
	[Test]
	public async Task TextInputTest()
	{
		await TextInputButton().ClickAsync();
		Pages.TextInputPage textInputPage = new(Page);
		await Expect(Page).ToHaveURLAsync("http://uitestingplayground.com/textinput");
		await Expect(textInputPage.MyButtonInput()).ToHaveAttributeAsync("placeholder","MyButton");
		await Expect(textInputPage.UpdatingButton()).ToHaveTextAsync("Button That Should Change it's Name Based on Input Value");
		await textInputPage.InputEnterText("dupa kota");
		await textInputPage.ClickButton();
		await Expect(textInputPage.UpdatingButton()).ToHaveTextAsync("dupa kota");
	}
	
	[Test]
	public async Task VerifyTextTest()
	{
		await VerifyTextButton().ClickAsync();
		Pages.VerifyTextPage verifyTextPage = new(Page);
		await Expect(Page).ToHaveURLAsync("http://uitestingplayground.com/verifytext");
		await Expect(verifyTextPage.PageLabel()).ToHaveTextAsync("Verify Text");
		await Expect(verifyTextPage.HelloUsernameText()).ToHaveTextAsync("Hello UserName!");
	}
}