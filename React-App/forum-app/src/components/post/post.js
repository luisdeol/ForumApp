import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './post.css';

class Post extends Component {
    componentDidMount() {
        const { id } = this.props.match.params;

        this.setState({
            id: id
        });
    }

    render() {
        const { id } = this.props.match.params;

        if (!id) {
            return <div>Loading...</div>
        }

        return (
            <div className="post">
                <h2>Post { id }</h2>
                <Link to="/" className="btn btn-link">Back</Link>
                <h4>Comments</h4>
            </div>
        )
    }
}

export default Post;