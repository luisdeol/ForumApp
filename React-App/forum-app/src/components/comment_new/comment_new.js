import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import { connect } from 'react-redux';

import { createComment } from '../../actions/index';

class CommentNew extends Component { 
    constructor(props) {
        super(props);

        const { postId } = this.props;

        this.state = {
            postId: postId
        }; 
    }

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

    onSubmit(values){
        values.postId = this.state.postId;
        this.props.createComment(values);
        this.props.reset();
    }

    render() {
        const { handleSubmit } = this.props;

        return (
            <form onSubmit={handleSubmit(this.onSubmit.bind(this))}>
                <Field 
                    name="content"
                    component={this.renderField}
                    label="content"
                    />
                <button type="submit" className="btn btn-primary">
                    Add New Comment
                </button>
            </form>)
    }
}

function validate(values) {
    const errors = {};

    return errors;
}

export default reduxForm({
    validate,
    form: 'CommentForm'
})(
    connect (null, {createComment})(CommentNew)
)