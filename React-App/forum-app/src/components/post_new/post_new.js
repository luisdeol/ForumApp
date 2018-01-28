import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

import { createPost } from '../../actions/index';
import './post_new.css'

class PostNew extends Component {
    renderField(field){
        const { meta: { touched, error } } = field
        const className = `form-group ${touched && error ? 'has-danger' : ''}`;
        return (
            <div className={className}>
                <label>{field.label}</label>
                <input
                    type="text"
                    className="form-control"
                    {...field.input} />
                <div className="text-help">
                  {touched ? error : ''}
                </div>
            </div>
        )
    }

    onSubmit(values) {
        this.props.createPost(values, () => {
            this.props.history.push('/');
        });
    }

    render(){
        const { handleSubmit } = this.props;

        return (
            <div>
                <form onSubmit={handleSubmit(this.onSubmit.bind(this))} className="post-new">
                    <h3>New Post</h3>
                    <Link to="/" className="btn btn-link">Back</Link>
                    <Field
                        label="Title"
                        name="title"
                        component={this.renderField} />
                    <Field
                        label="Content"
                        name="content"
                        component={this.renderField} />
                    <button type="submit" className="btn btn-primary">Submit</button>
                </form>
            </div>
        )
    }
}

function validate(values) {
    const errors = {};

    if (!values.content){
        errors.content = "Enter some content please";
    }

    if (!values.title || values.title.length < 5){
        errors.title = "Enter a minimum of 5 characters Title ";
    }
    
    return errors;
}

export default reduxForm({
    validate,
    form: 'PostsNewForm'
})(
    connect(null, { createPost }) (PostNew)
);