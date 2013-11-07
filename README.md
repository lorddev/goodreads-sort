flaming-octo-batman
===================

A simple Goodreads API app that sorts your books by percent completed. This is similar to the widget on the landing page that has 
your 10 most recent books in it, but on the site, there is no way to sort by percent completed.

This app is extremely useful for people who read a lot of books at the same time.

### Use Case 1

I am currently somewhere in the middle of 48 books. I also have a current goal of reading 30 books this year, and I 
have about 13 left before the year is over. The most efficient way for me to reach my goal and simultaneously shorten my ridiculously overwhelming list
is to sort my books by percent-completed (another method would be to sort by pages remaining, but with eBooks this won't be easy.)

### Pseudocode

1) Make call:

    https://www.goodreads.com/review/list/15469076?format=json&key=iBGqAvHjYE9W1CrqyreXRA&v=2&shelf=currently-reading&per_page=200

2) Iterate through and make calls for each book Id, e.g. 748010267

    https://www.goodreads.com/user_status/show/34980137?format=xml&key=iBGqAvHjYE9W1CrqyreXRA&user_id=15469076-aaron-lord

3) Response contains node with percent completion in prose, e.g.

     <header>\n\t
      <![CDATA[
        Aaron Lord is 74% done with <a href="http://www.goodreads.com/review/show/748010267">A Clash of Kings</a>
      ]]>
    </header>

4) Parse title and percent. If pages, calculate percent.  
5) Sort and output list. 
