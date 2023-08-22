const { chromium } = require('playwright');

(async () => {
  const browser = await chromium.launch();
  const page = await browser.newPage();

  await page.goto('http://localhost:4200/add');

  await page.fill('input[formControlName="FirstName"]', 'John');
  await page.fill('input[formControlName="Surname"]', 'Doe');
  await page.fill('input[formControlName="Address"]', '123 Elm St.');
  await page.fill('input[formControlName="PhoneNumber"]', '123-456-7890');
  await page.fill('input[formControlName="IBAN"]', 'IBAN123456789');

  await page.click('button[type="submit"]');

  await page.waitForTimeout(2000);

  const notificationText = await page.textContent('.success-notification');
  if (notificationText === 'Contact added successfully!') {
    console.log('Test Passed: Contact added successfully');
  } else {
    console.log('Test Failed');
  }

  await browser.close();
})();
