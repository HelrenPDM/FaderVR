import scrapy
from scrapy.spiders import CrawlSpider
from scrapy.selector import Selector
from jw_reddit_spider.items import JWRedditItem

class JWRedditCrawler(CrawlSpider):
    name = 'jw-reddit-crawler'
    allowed_domains = ['reddit.com', 'youtube.com']
    start_urls = ['https://www.reddit.com/r/exjw']

    def parse(self, response):
        s = Selector(response)
        next_link = s.xpath('//span[@class="nextprev"]//a/@href').extract()[0]
        if len(next_link):
            yield self.make_requests_from_url(next_link)
            posts = Selector(response).xpath('//div[@id="siteTable"]/div[@onclick="click_thing(this)"]')
            for post in posts:
                i = JWRedditItem()
                i['title'] = post.xpath('div[2]/p[1]/a/text()').extract()[0]
                i['desc'] = post.css('#form-t3_3g4460zec > div:nth-child(2) > div:nth-child(1)').extract()
                i['url'] = post.xpath('div[2]/ul/li[1]/a/@href').extract()[0]
                i['submitted'] = post.xpath('div[2]/p[2]/time/@title').extract()[0]
                yield i
