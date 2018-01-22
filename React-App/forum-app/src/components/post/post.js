import React, { Component } from 'react';

class Post extends Component {
    constructor(props){
        super(props);

        const newDate = new Date(props.post.creationDate).toLocaleString();

        this.state = {
            content: props.post.content,
            creationDate: newDate
        }
    }
    render() {
        return (
            <li className="list-group-item">
                <div className="row">
                    <div className="col-md-8">{this.state.content}</div>
                    <div clasName="col-md-4">
                    <p className="pull-right">
                        {this.state.creationDate}</p>
                    </div>
                </div>
            </li>
        )
    }
}

export default Post;