import React, { Component } from 'react';

export class Forces extends Component {
    displayName = Forces.name

    constructor(props) {
        super(props);
        this.state = {
            forces: [],
            forceDetail: null,
            persons: [],
            loading: true,
            changed: false,
            changed2: false,
            value: ''
        };

        this.handleChange = this.handleChange.bind(this);

        fetch('api/Forces')
            .then(response => response.json())
            .then(data => {
                this.setState({ forces: data, loading: false });
            });
    }

    handleChange(event) {
        //console.log(event.target.value);
        this.setState({ value: event.target.value });

        fetch('api/Forces/' + event.target.value)
            .then(response => response.json())
            .then(data => {
                this.setState({ forceDetail: data, changed: true });
            });

        fetch('api/Forces/' + event.target.value + '/people')
            .then(response => response.json())
            .then(data => {
                this.setState({ persons: data, changed2: true });
                console.log(this.state.persons);
            });
    }

    static renderForceDetail(forceDetail) {
        return (
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">{forceDetail.name}</h3>
                </div>
                <div class="panel-body">
                    <div dangerouslySetInnerHTML={Forces.createMarkup(forceDetail.description)}></div>
                    <p>Telephone: {forceDetail.telephone}</p>
                    <p>Url: <a href={forceDetail.url} target='_blank'>{forceDetail.url}</a></p>
                </div>
            </div>
        );
    };

    static renderPeople(persons) {
        return (
            <div className='row'>
                {persons.map(person =>
                    <div key={person.name} className='col-md-4'>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">{person.name}</h4>
                            </div>
                            <div class="panel-body">
                                <p>{person.rank}</p>
                                <a href={person.contact_details.twitter} target='_blank'>{person.contact_details.twitter}</a>
                            </div>
                        </div>
                    </div>
                )}
            </div>
        );
    };

    static createMarkup(html) {
        return { __html: html };
    }

    render() {
        let detail = this.state.changed ? Forces.renderForceDetail(this.state.forceDetail) : null;
        let people = this.state.changed2 ? Forces.renderPeople(this.state.persons) : null;

        return (
            <div>
                <h1>Forces</h1>
                <select id='force' className='form-control' onChange={this.handleChange} value={this.state.value}>
                    <option value=''>Please select...</option>
                    {this.state.forces.map(force =>
                        <option key={force.id} value={force.id}>{force.name}</option>
                    )}
                </select>
                <br />
                {detail}
                {people}
            </div>
        );
    }
}