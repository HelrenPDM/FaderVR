import scrapy

from jehovaswitness.items import JehovaswitnessItem

class JehovaswitnessSpider(scrapy.Spider):
    name = "jehovaswitness"
    start_urls = [
            "http://insidethewatchtower.com/",
    ]

    def parse(self, response):
        for href in response.css("article > div:nth-child(2) > p:nth-child(2) > a::attr('href')"):
            print '...parsing %s' %href.extract()
            url = response.urljoin(href.extract())
            yield scrapy.Request(url, callback=self.parse_article)

        prev_page = response.css("#nav-below > div.nav-previous > a::attr('href')")
        if prev_page:
            url = response.urljoin(prev_page[0].extract())
            yield scrapy.Request(url, self.parse)

    def parse_article(self, response):
        item = JehovaswitnessItem()
        item['title'] = response.xpath("//article/header/h1/text()").extract()
        item['link'] = response.url
        item['desc'] = response.css(".entry-content > p").extract()
        yield item

