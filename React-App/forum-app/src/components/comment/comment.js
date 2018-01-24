import React from 'react';

const Comment = ({ content, id }) => {
    return (
        <li className="list-group-item" key={id}>
            {content}
        </li>)
}

export default Comment;