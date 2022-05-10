import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';

import { USERS_API_URL } from '../../constants';

class RegistrationForm extends React.Component {

    state = {
        id: 0,
        name: '',
        document: '',
        email: '',
        phone: ''
    }

    componentDidMount() {
        if (this.props.user) {
            const { id, name, document, email, phone } = this.props.user
            this.setState({ id, name, document, email, phone});
        }
    }

    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitNew = e => {
        e.preventDefault();
        fetch(`${USERS_API_URL}`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                nome: this.state.name,
                cpf : this.state.document,
                email: this.state.email,
                telefone: this.state.phone
            })
        })
            .then(res => res.json())
            .then(user => {
                this.props.addUserToState(user);
                this.props.toggle();
            })
            .catch(err => console.log(err));
    }

    submitEdit = e => {
        e.preventDefault();
        fetch(`${USERS_API_URL}/${this.state.id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id:this.state.id,
                nome: this.state.name,
                cpf: this.state.document,
                email: this.state.email,
                telefone: this.state.phone
            })
        })
            .then(() => {
                this.props.toggle();
                this.props.updateUserIntoState(this.state.id);
            })
            .catch(err => console.log(err));
    }

    render() {
        return <Form onSubmit={this.props.user ? this.submitEdit : this.submitNew}>
            <FormGroup>
                <Label for="name">Nome:</Label>
                <Input type="text" name="name" onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name} />
            </FormGroup>
            <FormGroup>
                <Label for="document">CPF:</Label>
                <Input type="text" name="document" onChange={this.onChange} value={this.state.document === null ? '' : this.state.document} />
            </FormGroup>
            <FormGroup>
                <Label for="email">Email:</Label>
                <Input type="email" name="email" onChange={this.onChange} value={this.state.email === null ? '' : this.state.email} />
            </FormGroup>
            <FormGroup>
                <Label for="phone">Telefone:</Label>
                <Input type="text" name="phone" onChange={this.onChange} value={this.state.phone === null ? '' : this.state.phone}
                    placeholder="(11) 99999-9999" />
            </FormGroup>
            <Button>Cadastrar</Button>
        </Form>;
    }
}

export default RegistrationForm;