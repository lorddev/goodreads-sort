# goodreads-sort

A simple Goodreads API app that sorts your books by percent completed. This is similar to the widget on the landing page that has 
your 10 most recent books in it, but on the site, there is no way to sort by percent completed.

This app is extremely useful for people who read a lot of books at the same time.

### Use Case 1

I am currently somewhere in the middle of 48 books. I also have a current goal of reading 30 books this year, and I 
have about 13 left before the year is over. The most efficient way for me to reach my goal and simultaneously shorten my 
ridiculously overwhelming list is to sort my books by percent-completed (another method would be to sort by pages remaining, but 
with eBooks this won't be easy.)

### Pseudocode

1) Make call:

    https://www.goodreads.com/review/list/15469076?format=json&key=iBGqAvHjYE9W1CrqyreXRA&v=2&shelf=currently-reading&per_page=200

2) Iterate through and make calls for each review Id, e.g. 
    
    https://www.goodreads.com/review/show/?id=545689321&format=xml&key=iBGqAvHjYE9W1CrqyreXRA&user_id=15469076-aaron-lord

3) Response contains book info and user statuses. Parse the book title from the `<book/>` node. Parse the percent value from the most recent `<user_status/>` entry.

    <user_statuses>
		<user_status>
			<chapter type="integer" nil="true"/>
			<comments_count type="integer">0</comments_count>
			<created_at type="datetime">2013-10-30T03:38:09+00:00</created_at>
			<id type="integer">34677179</id>
			<last_comment_at type="datetime" nil="true"/>
			<note_updated_at type="datetime" nil="true"/>
			<note_uri nil="true"/>
			<page type="integer" nil="true"/>
			<percent type="integer">19</percent>
			<ratings_count type="integer">0</ratings_count>
			<updated_at type="datetime">2013-10-30T03:38:09+00:00</updated_at>
			<work_id type="integer">481941</work_id>
			<body/>
		</user_status>
		<user_status>
		   ...
		</user_status>
	</user_statuses>

4) Sort and output list. 

![Image](ScreenClip.png)
