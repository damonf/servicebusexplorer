import { ServiceBusExplorerPage } from './app.po';

describe('service-bus-explorer App', () => {
  let page: ServiceBusExplorerPage;

  beforeEach(() => {
    page = new ServiceBusExplorerPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
