import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class PostItem extends Component {
    constructor(props){
        super(props);

        const newDate = new Date(props.post.creationDate).toLocaleString();

        this.state = {
            content: props.post.content,
            creationDate: newDate,
            id: props.post.id
        }
    }

    render() {
        return (
            <li className="list-group-item">
                <Link to={`/posts/${this.state.id}`}>
                    <div className="row">
                        <div className="col-md-8">{this.state.content}</div>
                        <div className="col-md-4">
                        <p className="pull-right">
                            {this.state.creationDate}</p>
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