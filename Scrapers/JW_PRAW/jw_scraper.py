# -*- coding: utf-8 -*-
import time
import praw
import webbrowser
import sqlite3 as lite
import sys
import codecs

# start db connection
con = lite.connect('reddit.db')
con.text_factory = lambda x: unicode(x, 'utf-8', 'ignore')

with con:
    cur = con.cursor()
    cur.execute('SELECT SQLITE_VERSION()')

    data = cur.fetchone()

    print "SQLite version: %s" % data

    cur.execute("DROP TABLE IF EXISTS Reddit_jw")
    con.commit()
    cur.execute("CREATE TABLE Reddit_jw(Id TEXT, Author TEXT, Content TEXT, Time DATETIME, Link TEXT)")
# end db connection

# init reddit access
r = praw.Reddit('Taxonomy related comment monitor by /u/HelrenPDM 0.1')
r.set_oauth_app_info(client_id='uiLtEWo0uJZOGw',
        client_secret='ZGNHynAf5H8w-Lsz1GegFMjLtgs',
        redirect_uri='http://127.0.0.1:65010/authorize_callback')
r.login('HelrenPDM', '$IIub1966$')
subreddit = r.get_subreddit('exjw')
# end reddit access

already_done = []

taxonomy = [
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
        'Governing Body',
        'Australia',
        'Commission',
        'Congregation',
        'Geoffrey Jackson',
        'Vincent Toole',
        'Stephen Lett'
        ]

taxonomyTOPIC = [
        'Governing Body',
        'Australia',
        'GB',
        'Commission',
        'Congregation'
        ]

taxonomyPEOPLE = [
        'Geoffrey Jackson',
        'Vincent Toole',
        'Stephen Lett'
        ]

while True:
    for submission in subreddit.get_top_from_all(limit=100):
        op_text = submission.selftext.lower()
        op_title = submission.title.lower()
        has_taxonomy = any(string in op_text for string in str(taxonomy).lower())
        has_TOPIC = any(string in op_text for string in str(taxonomyTOPIC).lower()) or any(string in op_title for string in str(taxonomyTOPIC).lower())
        has_PEOPLE = any(string in op_text for string in str(taxonomyPEOPLE).lower()) or any(string in op_title for string in str(taxonomyPEOPLE).lower())
        if submission.id not in already_done and (has_TOPIC or has_PEOPLE) and has_taxonomy:
            if submission.author is None:
                subname = "Aouthor deleted"
            else:
                subname = submission.author.name
            msg = "[Taxonomy related thread]({}, {}, {}, {})".format(submission.id, subname, submission.selftext.encode('utf-8'), submission.short_link)
            print 'Found: %s' % msg
            already_done.append(submission.id)
            cur.execute("""INSERT INTO Reddit_jw(Id, Author, Content, Link) VALUES(?,?,?,?,?);""", [submission.id, subname, submission.selftext.encode('utf-8'), submission.created_utc, submission.short_link])

            flat_comments = praw.helpers.flatten_tree(submission.comments)
            for comment in flat_comments:
                if not hasattr(comment, 'body'):
                    continue
                has_praw_comment = any(string in comment.body.lower() for string in str(taxonomy).lower())
                if has_praw_comment:
                    if comment.author is None:
                        comname = "Author deleted"
                    else:
                        comname = comment.author.name
                    cmsg = "[Taxonomy related comment]({}, {}, {}, {})".format(comment.id, comname, comment.body.encode('utf-8'), comment.permalink)
                    print 'Found: %s' % cmsg
                    cur.execute("""INSERT INTO Reddit_jw(Id, Author, Content, Link) VALUES(?,?,?,?,?);""", [comment.id, comname, comment.body, comment.created_utc, comment.permalink])
    con.commit()
    time.sleep(1800)

