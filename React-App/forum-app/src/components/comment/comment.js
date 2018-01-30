import React from 'react';

const Comment = ({ content, id, creationdate }) => {
    const creationDateLocale = new Date(creationdate).toLocaleString();
    return (
        <li className="list-group-item" key={id}>
            <div className="row">
                <div className="col-md-8">{content}</div>
                <div className="col-md-4">{creationDateLocale}</div>
            </div>
        </li>)
}

export default Comment;