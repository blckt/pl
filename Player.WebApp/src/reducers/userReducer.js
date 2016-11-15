import { REGISTER, LOGOUT } from '../constants/userContants';

let user = {
    token: null
}


const userReducer = (state = user, action) => {
    switch (action.type) {
        case REGISTER: {
            if (action.token) {
                return Object.assign({}, state, action.token);
            }
            break;
        }
        case LOGOUT: {
            return Object.assign({}, user);
        }
        default: return state;
    }
}

export default userReducer;
