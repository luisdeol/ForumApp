import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import { connect } from 'react-redux';
import { createPost } from '../../actions/index';

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
            <form onSubmit={handleSubmit(this.onSubmit.bind(this))}>
                <Field
                    label="Content"
                    name="content"
                    component={this.renderField} />
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        )
    }
}

function validate(values) {
    const errors = {};

    if (!values.content){
        errors.content = "Enter some content please";
    }

    return errors;
}

export default reduxForm({
    validate,
    form: 'PostsNewForm'
})(
    connect(null, { createPost }) (PostNew)
);