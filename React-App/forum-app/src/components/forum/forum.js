import React, { Component } from 'react';
import _ from 'lodash';
import Post from '../post/post';

class Forum extends Component {
    renderPosts() {
        const posts = [{ content: 'content 1'}, { content: 'content 2'}];
        
        return _.map(posts, post => {
            return (
                <Post content={post.content}/>
            )
        })
    }

    render(){
        return (
            <div>
                <h1>Forum</h1>
                <ul>
                    {this.renderPosts()}
                </ul>
            </div>
        )
    }
}

export default Forum;