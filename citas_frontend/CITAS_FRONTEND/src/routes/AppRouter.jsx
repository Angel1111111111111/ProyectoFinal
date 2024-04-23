import { Route, Routes } from "react-router-dom"
import { LoginPage, Register } from "../pages"
import { PublicRoute } from "./PublicRoute"
import { PrivateRoute } from "./PrivateRoute"
import { HistorialCitas, HistorialMedico, Services, TodoFormCita } from "../components"
import { Dermatologist } from "../medicalServices/Dermatologist"
import { MedicalExams } from "../medicalServices"

export const AppRouter = () => {
    return (
        <>
            <Routes>
                <Route
                    path='/login' element={
                        <PublicRoute>
                            <LoginPage />
                        </PublicRoute>
                        //     <PublicRoute>
                        //     <ResetPasswordPage />
                        // </PublicRoute>
                    }
                />
                <Route
                    path='/' element={
                        <PublicRoute>
                            <Services />
                        </PublicRoute>
                    }
                />
                <Route
                    path='/todoForm'
                    element={
                        <PublicRoute>
                            <TodoFormCita />
                        </PublicRoute>
                    }
                />
                <Route
                    path='/register'
                    element={
                        <PublicRoute>
                            <Register />
                        </PublicRoute>
                    }
                />
                <Route
                    path='/historialMedico'
                    element={
                        <PublicRoute>
                            <HistorialMedico />
                        </PublicRoute>
                    }
                />
                <Route
                    path='/historialCita'
                    element={
                        <PublicRoute>
                            <HistorialCitas />
                        </PublicRoute>
                    }
                />
                <Route
                    path='/08dc61b1-2a73-474a-8a2e-825eeeaaf7fa'
                    element={
                        <PublicRoute>
                            <Dermatologist />
                        </PublicRoute>
                    }
                />
                <Route
                    path='/08dc61b2-fdf3-49af-845f-0a0e14677acd'
                    element={
                        <PublicRoute>
                            <MedicalExams />
                        </PublicRoute>
                    }
                />
            </Routes>
        </>
    )
}
