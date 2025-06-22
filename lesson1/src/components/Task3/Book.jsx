import React from 'react';

function BookInfo() {
  const book = {
    title: "The Hitchhiker's Guide to the Galaxy",
    author: {
      firstName: "Douglas",
      lastName: "Adams",
      fullName: "Douglas Adams"
    },
    genre: "Science Fiction, Comedy, Satire",
    pageCount: 193, // Approximate page count for the first book in the series
    reviews: [
      {
        id: 1,
        reviewer: "Critic1",
        comment: "Good!"
      },
      {
        id: 2,
        reviewer: "Critic2",
        comment: "Good!"
      },
      {
        id: 3,
        reviewer: "Critic3",
        comment: "Good!"
      }
    ]
  };
   
  return (
    <div className="book-info-container">
      <h1 className="book-title">Book: "{book.title}"</h1>
      <p className="book-author">Author: {book.author.fullName}</p>
      <p className="book-genre">Genre: {book.genre}</p>
      <p className="book-pages">Pages: {book.pageCount}</p>

      <h2 className="reviews-heading">Reviews:</h2>
      <ul className="reviews-list">
        {book.reviews.map((review) => (
          <li key={review.id} className="review-item">
            <p className="review-reviewer">{review.reviewer}</p>
            <p className="review-comment">"{review.comment}"</p>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default BookInfo;