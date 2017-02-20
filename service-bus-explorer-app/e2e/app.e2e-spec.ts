import { ServiceBusExplorerAppPage } from './app.po';

describe('service-bus-explorer-app App', function() {
  let page: ServiceBusExplorerAppPage;

  beforeEach(() => {
    page = new ServiceBusExplorerAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
