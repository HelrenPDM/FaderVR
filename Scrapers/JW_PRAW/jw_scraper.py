import time
import praw
import webbrowser

r = praw.Reddit('Taxonomy related comment monitor by /u/HelrenPDM 0.1')
r.set_oauth_app_info(client_id='uiLtEWo0uJZOGw',
        client_secret='ZGNHynAf5H8w-Lsz1GegFMjLtgs',
        redirect_uri='http://127.0.0.1:65010/authorize_callback')
r.login('HelrenPDM', '$IIub1966$')

already_done = []

prawWords = [
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
        'Take a swig'
        ]
while True:
    subreddit = r.get_subreddit('exjw')
    for submission in subreddit.get_top_from_all(limit=100):
        op_text = submission.selftext.lower()
        has_praw = any(string in op_text for string in str(prawWords).lower())
        if submission.id not in already_done and has_praw:
            msg = '[Taxonomy related thread](%s)' %submission.short_link
            print 'Found: %s' % msg
            r.send_message('HelrenPDM', 'JW Thread', msg)
            already_done.append(submission.id)
        flat_comments = praw.helpers.flatten_tree(submission.comments)
        for comment in flat_comments:
            has_praw_comment = any(string in comment.body.lower() for string in str(prawWords).lower())
            if has_praw_comment:
                print 'Found: %s' %comment.body
                cmsg = '[Taxonomy related comment](%s)' %comment.permalink
                r.send_message('HelrenPDM', 'JW Comment', cmsg)
    time.sleep(1800)
