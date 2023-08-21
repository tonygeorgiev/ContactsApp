const { chromium } = require('playwright');

(async () => {
  const browser = await chromium.launch();
  const page = await browser.newPage();
  await page.goto('http://localhost:4200');

  const title = await page.title();
  console.assert(title === 'ContactsApp', `Expected app title, but got ${title}`);

  await browser.close();
})();
