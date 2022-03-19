USE catalog;
INSERT INTO movies (title, directorId, actorIds, publicationYear, categoryIds) VALUES
("The Lord of the Rings: The Fellowship of the Ring", 1, "1,2,3", 2001, "4,5,6"),
("The Lord of the Rings: The Two Towers", 1, "1,2,4", 2002, "4,5,6"),
("The Lord of the Rings: The Return of the King", 1, "1,4,2", 2003, "4,5,6"),
("Batman Begins", 2, "5,6,7", 2005, "7,4"),
("The Dark Knight", 2, "5,8,9", 2008, "7,3,5"),
("The Dark Knight Rises", 2, "5,10,11", 2012, "7,8"),
("Inception", 2, "12,13,14", 2010, "7,4,9"),
("Ted", 3, "15,16,17", 2012, "2,6"),
("Ted 2", 3, "15,17,18", 2015, "2"),
("Deadpool", 4, "19,20,21", 2016, "7,4,2"),
("Night School", 5, "22,23,24", 2018, "2"),
("Sherlock Holmes", 6, "25,26,27", 2009, "7,4,3"),
("Sherlock Holmes: A Game of Shadows", 6, "25,26,28", 2011, "7,4,3"),
("Shrek", 7, "29,30,31", 2001, "10,4,2"),
("Shrek 2", 7, "29,30,31", 2004, "10,4,2"),
("Shrek the Third", 8, "29,31,30", 2007, "10,4,2"),
("Shrek Forever After", 9, "29,31,30", 2010, "10,4,2"),
("Your Name.", 10, "32,33,34", 2016, "10,5,6"),
("Loving Pablo", 11, "35,36,37", 2017, "7,11,3"),
("The Theory of Everything", 12, "38,39,40", 2014, "11,5,12"),
("The Social Network", 13, "41,42,43", 2010, "11,5"),
("Zodiac", 13, "44,25,45", 2007, "3,5,13"),
("Inside Out", 14, "46,47,48", 2015, "10,4,2"),
("The Purge", 15, "49,50,51", 2013, "14,8"),
("Bel Ami", 16, "52,53,54", 2012, "5,15,12"),
("The Great Gatsby", 17, "12,55,56", 2013, "5,12"),
("Harry Potter and the Sorcerer's Stone", 18, "57,58,59", 2001, "4,16,6"),
("Harry Potter and the Chamber of Secrets", 18, "57,58,60", 2002, "4,16,6"),
("Harry Potter and the Prisoner of Azkaban", 19, "57,60,58", 2004, "4,16,6"),
("Harry Potter and the Goblet of Fire", 20, "57,60,58", 2005, "4,16,6"),
("Harry Potter and the Order of the Phoenix", 21, "57,60,58", 2007, "4,16,6"),
("Harry Potter and the Half-Blood Prince", 21, "57,60,58", 2009, "4,16,6"),
("Harry Potter and the Deathly Hallows: Part 1", 21, "57,60,58", 2010, "4,6,13"),
("Harry Potter and the Deathly Hallows: Part 2", 21, "57,60,58", 2011, "4,5,6");