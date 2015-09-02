# -*- coding: utf-8 -*-

# Define your item pipelines here
#
# Don't forget to add your pipeline to the ITEM_PIPELINES setting
# See: http://doc.scrapy.org/en/latest/topics/item-pipeline.html

from scrapy.exceptions import DropItem


class JehovaswitnessPipeline(object):
    """A pipeline to return items, which contain terms from the taxonomy"""

    # all in lowercase
    words_to_filter = [
            'stephen lett',
            'child abuse',
            'sexual abuse',
            'molested',
            'rape',
            'raped',
            'pedophile',
            'pedophilia',
            'child molester',
            'disfellowshipping',
            'disfellowshipped',
            'disfellowship',
            'shunning',
            'shunned',
            'shun',
            'disassociation',
            'disassociated',
            'disassociate',
            'charities commission',
            'investigation',
            'royal commission',
            'governing body',
            'secular authories',
            'two-witness rule',
            'two witnesses',
            'clergy privilege',
            'stephen lett',
            'gerrit losch',
            'mark sanderson',
            'anthony morris',
            'geoffrey jackson',
            'samuel herd',
            'david splane',
            'james mccabe',
            'jim mccabe',
            'ronald lawrence',
            'jonathan kendrick',
            'debbie mcdaniel',
            'candace conti',
            'irwin zalkin',
            'linda hood',
            'allen shuster',
            'michael clarke',
            'gary abrahamson',
            'larry lamerdin',
            'jose lopez',
            'gonzalo campos'
    ]

    def process_item(self, item, spider):
        item['keywords'] = {}
        for word in self.words_to_filter:
            temptitle = str(item['title']).lower()
            templink = str(item['link']).lower()
            tempdesc = str(item['desc']).lower()
            if item['keywords'].has_key(word):
                item['keywords'][word] = item['keywords'][word] + 1
            else:
                if word in temptitle:
                    item['keywords'][word] = 1
                elif word in templink:
                    item['keywords'][word] = 1
                elif word in tempdesc:
                    item['keywords'][word] = 1
        if item['keywords'] == {}:
            raise DropItem("%s not found in source" % word)
        else:
            return item
