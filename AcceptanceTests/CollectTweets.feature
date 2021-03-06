Feature: Collects tweets from the tweets

Scenario: Collects tweets
  Given the twitter login api responds with 
  """
  {
      "access_token": "a superlong token"
  }
  """

  And the twitter api responds with 
  """
  {
    "created_at": "Tue Feb 04 04:27:51 +0000 2020",
    "id_str": "1224550106462138368",
    "text": "Big WIN for us in Iowa tonight. Thank you!",
    "truncated": false,
    "user": {
        "screen_name": "realDonaldTrump",
        },
    "is_quote_status": false,
    "retweet_count": 1467,
    "favorite_count": 5989,
    "favorited": false,
    "retweeted": false,
    "possibly_sensitive": false

  }
  """
  When I trigger the function GetTweets
  Then I expect a file named twitter.json to have
  """
  [
    {
      "created_at": "Tue Feb 04 04:27:51 +0000 2020",
      "id_str": "1224550106462138368",
      "text": "Big WIN for us in Iowa tonight. Thank you!",    
      "screen_name": "realDonaldTrump",
      "is_positive" : true
    }
  ]
  """