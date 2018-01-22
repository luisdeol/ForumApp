import React, { Component } from 'react';
import _ from 'lodash';
import Post from '../post/post';
import { connect } from 'react-redux';
import { fetchPosts } from '../../actions/index';
import { Link } from 'react-router-dom';

import './forum.css';

class Forum extends Component {
    componentDidMount() {
        this.props.fetchPosts();
    }

    renderPosts() {
        const posts = this.props.posts;
        
        return _.map(posts, post => {
            return (
                <Post post={post} key={post.id} />
            )
        })
    }

    render(){
        return (
            <div className="forum">
                <h1>Forum</h1>
                <Link className="btn btn-primary" to="/posts/new">
                    Add a Post
                </Link>
                <ul className="list-group list-post">
                    {this.renderPosts()}
                </ul>
            </div>
        )
    }
}

function mapStateToProps(state) {
    return { posts: state.posts };
}

export default connect(mapStateToProps, { fetchPosts }) (Forum);