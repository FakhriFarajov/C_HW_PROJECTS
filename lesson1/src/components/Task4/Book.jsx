import React from 'react';

class BookInfoClass extends React.Component {
  constructor(props) {
    super(props); // Always call super(props) first
    this.state = {
      book: {
        title: "The Hitchhiker's Guide to the Galaxy",
        author: {
          firstName: "Douglas",
          lastName: "Adams",
          fullName: "Douglas Adams"
        },
        genre: "Science Fiction, Comedy, Satire",
        pageCount: 193,
        reviews: [
          {
            id: 1,
            reviewer: "Critic (A.I.)",
            comment: "Absolutely hilarious and clever! A must-read for all fans of humor and space."
          },
          {
            id: 2,
            reviewer: "Reader (Elena S.)",
            comment: "My favorite book! Full of absurd humor and unexpected twists. Incredibly creative."
          },
          {
            id: 3,
            reviewer: "Goodreads (Rating 4.2/5)",
            comment: "A classic of humorous science fiction. A book that makes you think and laugh at the same time."
          }
        ]
      },
    };
  }

  render() {
    const { book } = this.state;

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
              <p className="review-reviewer">**{review.reviewer}**</p>
              <p className="review-comment">"{review.comment}"</p>
            </li>
          ))}
        </ul>
      </div>
    );
  }
}

export default BookInfoClass;