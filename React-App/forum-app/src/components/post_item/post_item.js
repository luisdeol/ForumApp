import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class PostItem extends Component {
    constructor(props){
        super(props);

        const newDate = new Date(props.post.creationDate).toLocaleString();
        
        props.post.creationDate = newDate;

        this.state = {
            post: props.post
        }
    }

    render() {
        const {id, creationDate, title } = this.state.post;

        return (
            <li className="list-group-item">
                <Link to={`/posts/${id}`}>
                    <div className="row">
                        <div className="col-md-8">{title}</div>
                        <div className="col-md-4">
                        <p className="pull-right">
                            {creationDate}</p>
                        </div>
                    </div>
                    <div className="row">

                    </div>
                </Link>
            </li>
        )
    }
}

export default PostItem;