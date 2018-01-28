import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import _ from 'lodash';
import { connect } from 'react-redux';

import './post.css';
import Comment from '../comment/comment';
import CommentNew from '../comment_new/comment_new';
import { fetchComments, cleanCommentsState } from '../../actions/index';

class Post extends Component {
    componentDidMount(){
        this.props.cleanCommentsState();
        this.props.fetchComments(this.props.match.params.id);
    }

    constructor(props) {
        super(props);

        const { id } = this.props.match.params;

        this.state = {
            id: id
        };
    }

    renderComments() {
        const comments = this.props.comments;
        
        return _.map(comments, comment => {
            return (<Comment content={comment.content} id={comment.id} key={comment.id}/>)
        })
    }

    render() {
        const id = this.state.id;

        if (!id) {
            return <div>Loading...</div>
        }

        return (
            <div className="post">
                <h2>Post { id }</h2>
                <Link to="/" className="btn btn-link">Back</Link>
                <h4>Comments</h4>
                <CommentNew postId={id}/>
                <ul className="list-group">
                    {this.renderComments()}
                </ul>
            </div>
        )
    }
}

function mapStateToProps(state){
    return {
        comments: state.comments
    }
}

export default connect(mapStateToProps, 
                { fetchComments, cleanCommentsState })(Post);