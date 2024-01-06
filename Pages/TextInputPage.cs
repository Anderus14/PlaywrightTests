using Microsoft.Playwright;

namespace PlaywrightTests
{ 
	public class TextInputPage
	{
		private IPage _page;
		public ILocator PageLabel() => _page.Locator("//h3[text='Text Input']");
		public ILocator MyButtonInput() => _page.Locator("#newButtonName");
		public ILocator UpdatingButton() => _page.Locator("#updatingButton");
		public TextInputPage(IPage page) => _page = page;

		public async Task InputEnterText(string text) => await MyButtonInput().FillAsync(text);

		public async Task ClickButton() => await UpdatingButton().ClickAsync();
	}
}
