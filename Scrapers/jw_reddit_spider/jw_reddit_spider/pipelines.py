# -*- coding: utf-8 -*-

# Define your item pipelines here
#
# Don't forget to add your pipeline to the ITEM_PIPELINES setting
# See: http://doc.scrapy.org/en/latest/topics/item-pipeline.html
import re
from scrapy.exceptions import DropItem


class JehovaswitnessPipeline(object):
    """A pipeline to return items, which contain terms from the taxonomy"""

    # all in lowercase
    words_to_filter = [
            'Geoffrey Jackson',
            'Vincent Toole',
            'Governing Body',
            'Testimony',
            'Testify',
            'Lie',
            'Lying',
            'Liar',
            'Bullshit',
            'Truth',
            'Theocratic Warfare',
            'Theocratic Warfare Doctrine',
            'Theocratic War Strategy',
            '1957',
            '1954',
            '1960',
            'Enemies',
            "God's Enemies",
            "Satan's Organization",
            'Take a drink',
            'Take a swig',
    ]

    def process_item(self, item, spider):
        item['keywords'] = {}
        for word in self.words_to_filter:
            print 'Searching for %s' % word
            temptitle = str(item['title']).lower()
            tempdesc = str(item['desc']).lower()
            if item['keywords'].has_key(word):
                item['keywords'][word] = item['keywords'][word] + 1
            else:
                if str(word).lower() in temptitle:
                    item['keywords'][word] = 1
                elif str(word).lower() in tempdesc:
                    item['keywords'][word] = 1
        if item['keywords'] == {}:
            raise DropItem("%s not found in source" % item['keywords'])
        else:
            return item
