import React, { Component } from 'react';

class Post extends Component {
    constructor(props){
        super(props);

        this.state = {
            content: props.content
        }
    }
    render() {
        return (
            <li>{this.state.content}</li>
        )
    }
}

export default Post;